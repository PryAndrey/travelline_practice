import fs from 'fs';

type JsonValue = string | number | boolean | undefined | JsonObject;

type JsonObject = {
  [key: string]: JsonValue;
};

const toJson = (tempObj: JsonValue): JsonValue => {
  return (Array.isArray(tempObj))
    ? tempObj.reduce((obj, item, index) => {
      obj[index.toString()] = item;
      return obj;
    }, {} as JsonObject)
    : tempObj;
}

const compareObjects = (oldObject: JsonObject, newObject: JsonObject): JsonObject => {
  const compareResult: Record<string, JsonObject> = {};

  const keys = Array.from(new Set([...Object.keys(oldObject), ...Object.keys(newObject)]));

  keys.forEach(key => {
    const newObj = key in newObject && !(key in oldObject);
    const oldObj = key in oldObject && !(key in newObject);
    if (newObj || oldObj) {
      compareResult[key] = {
        type: newObj ? 'new' : 'delete',
        newValue: newObj ? newObject[key] : oldObject[key]
      };
    }
  });

  keys.forEach(key => {
    const oldValue = toJson(oldObject[key]);
    const newValue = toJson(newObject[key]);

    if (oldValue !== undefined && newValue !== undefined) {
      if (typeof oldValue === 'object' && typeof newValue === 'object') {
        const childrenDifference = compareObjects(oldValue, newValue);
        const hasChanged = Object.values(childrenDifference).some(child => (child as JsonObject).type !== 'unchanged');
        compareResult[key] = {
          type: !hasChanged ? 'unchanged' : 'changed',
          children: childrenDifference
        };
      } else {
        compareResult[key] = {
          type: oldValue === newValue ? 'unchanged' : 'changed',
          oldValue,
          newValue
        };
      }
    }
  });

  return compareResult;
};

export const jsonDiff = (oldFilePath: string, newFilePath: string) => {
  const oldData = JSON.parse(fs.readFileSync(oldFilePath, 'utf8'));
  const newData = JSON.parse(fs.readFileSync(newFilePath, 'utf8'));
  const jsonDifference = compareObjects(oldData, newData);
  console.log(JSON.stringify(jsonDifference, null, 2));
};