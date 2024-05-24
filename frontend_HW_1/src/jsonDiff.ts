import fs from 'fs';

type JsonObject = Record<string, unknown>;

type CompareResult = Record<string, {
  type: "new" | "delete" | "changed" | "unchanged",
  oldValue?: unknown,
  newValue?: unknown,
  children?: CompareResult,
}>;

const isJsonObject = (value: unknown): value is JsonObject => {
  return typeof value === 'object' && value !== null;
};

const compareObjects = (oldObject: JsonObject, newObject: JsonObject): CompareResult => {
  const keys = Array.from(new Set([...Object.keys(oldObject), ...Object.keys(newObject)]));

  return keys.reduce((compareResult, key) => {
    const oldValue = oldObject[key];
    const newValue = newObject[key];

    if (oldValue === undefined || newValue === undefined) {
      return {
        ...compareResult,
        [key]: newValue ? {
          type: 'new',
          newValue
        } : {
          type: 'delete',
          oldValue
        }
      };
    }

    if (isJsonObject(oldValue) && isJsonObject(newValue)) {
      const childrenDifference = compareObjects(oldValue, newValue);
      const hasChanged = Object.values(childrenDifference).some(child => child.type !== 'unchanged');
      return {
        ...compareResult,
        [key]: {
          type: !hasChanged ? 'unchanged' : 'changed',
          children: childrenDifference
        }
      };
    }

    return {
      ...compareResult,
      [key]: {
        type: oldValue === newValue ? 'unchanged' : 'changed',
        oldValue,
        newValue
      }
    };
  }, {});
};

export const jsonDiff = (oldFilePath: string, newFilePath: string) => {
  const oldData = JSON.parse(fs.readFileSync(oldFilePath, 'utf8'));
  const newData = JSON.parse(fs.readFileSync(newFilePath, 'utf8'));
  const jsonDifference = compareObjects(oldData, newData);
  return jsonDifference;
};