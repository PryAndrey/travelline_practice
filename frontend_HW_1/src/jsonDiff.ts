import fs from 'fs';

type JsonValue = string | number | boolean | undefined | JsonObject;

type JsonObject = {
  [key: string]: JsonValue;
};

type CompareResult = Record<string, {
  type: "new" | "delete" | "changed" | "unchanged",
  oldValue?: JsonValue,
  newValue?: JsonValue,
  children?: CompareResult,
}>;

//Conversation from array into json object 
const toJson = (tempObj: JsonValue): JsonValue => {
  return (Array.isArray(tempObj))
    ? tempObj.reduce((obj, item, index) => {
      obj[index.toString()] = item;
      return obj;
    }, {})
    : tempObj;
}

const compareObjects = (oldObject: JsonObject, newObject: JsonObject): CompareResult => {
  const keys = Array.from(new Set([...Object.keys(oldObject), ...Object.keys(newObject)]));

  return keys.reduce((compareResult, key) => {
    const oldObj = key in oldObject && !(key in newObject);
    const newObj = key in newObject && !(key in oldObject);
    if (oldObj || newObj) {
      return {
        ...compareResult,
        [key]: newObj ? {
          type: 'new',
          newValue: newObject[key]
        } : {
          type: 'delete',
          oldValue: oldObject[key]
        }
      };
    }

    const oldValue = toJson(oldObject[key]);
    const newValue = toJson(newObject[key]);
    if (oldValue !== undefined && newValue !== undefined) {
      if (typeof oldValue === 'object' && typeof newValue === 'object' && oldValue !== null && newValue !== null) {
        const childrenDifference = compareObjects(oldValue, newValue);
        const hasChanged = Object.values(childrenDifference).some(child => child.type !== 'unchanged');
        return {
          ...compareResult,
          [key]: {
            type: !hasChanged ? 'unchanged' : 'changed',
            children: childrenDifference
          }
        };
      } else {
        return {
          ...compareResult,
          [key]: {
            type: oldValue === newValue ? 'unchanged' : 'changed',
            oldValue,
            newValue
          }
        };
      }
    }
    return {
      ...compareResult
    }
  }, {});
};

export const jsonDiff = (oldFilePath: string, newFilePath: string) => {
  const oldData = JSON.parse(fs.readFileSync(oldFilePath, 'utf8'));
  const newData = JSON.parse(fs.readFileSync(newFilePath, 'utf8'));
  const jsonDifference = compareObjects(oldData, newData);
  return jsonDifference;
};