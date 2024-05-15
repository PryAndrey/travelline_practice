"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.jsonDiff = void 0;
const fs_1 = __importDefault(require("fs"));
const toJson = (tempObj) => {
    return (Array.isArray(tempObj))
        ? tempObj.reduce((obj, item, index) => {
            obj[index.toString()] = item;
            return obj;
        }, {})
        : tempObj;
};
const compareObjects = (oldObject, newObject) => {
    const compareResult = {};
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
                const hasChanged = Object.values(childrenDifference).some(child => child.type !== 'unchanged');
                compareResult[key] = {
                    type: !hasChanged ? 'unchanged' : 'changed',
                    children: childrenDifference
                };
            }
            else {
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
const jsonDiff = (oldFilePath, newFilePath) => {
    const oldData = JSON.parse(fs_1.default.readFileSync(oldFilePath, 'utf8'));
    const newData = JSON.parse(fs_1.default.readFileSync(newFilePath, 'utf8'));
    const jsonDifference = compareObjects(oldData, newData);
    console.log(JSON.stringify(jsonDifference, null, 2));
};
exports.jsonDiff = jsonDiff;
