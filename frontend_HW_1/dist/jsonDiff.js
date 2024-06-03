"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.jsonDiff = void 0;
const fs_1 = __importDefault(require("fs"));
const isJsonObject = (value) => {
    return typeof value === 'object' && value !== null;
};
const compareObjects = (oldObject, newObject) => {
    const keys = Array.from(new Set([...Object.keys(oldObject), ...Object.keys(newObject)]));
    return keys.reduce((compareResult, key) => {
        const oldValue = oldObject[key];
        const newValue = newObject[key];
        if (oldValue === undefined || newValue === undefined) {
            return Object.assign(Object.assign({}, compareResult), { [key]: newValue ? {
                    type: 'new',
                    newValue
                } : {
                    type: 'delete',
                    oldValue
                } });
        }
        if (isJsonObject(oldValue) && isJsonObject(newValue)) {
            const childrenDifference = compareObjects(oldValue, newValue);
            const hasChanged = Object.values(childrenDifference).some(child => child.type !== 'unchanged');
            return Object.assign(Object.assign({}, compareResult), { [key]: {
                    type: !hasChanged ? 'unchanged' : 'changed',
                    children: childrenDifference
                } });
        }
        return Object.assign(Object.assign({}, compareResult), { [key]: {
                type: oldValue === newValue ? 'unchanged' : 'changed',
                oldValue,
                newValue
            } });
    }, {});
};
const jsonDiff = (oldFilePath, newFilePath) => {
    const oldData = JSON.parse(fs_1.default.readFileSync(oldFilePath, 'utf8'));
    const newData = JSON.parse(fs_1.default.readFileSync(newFilePath, 'utf8'));
    const jsonDifference = compareObjects(oldData, newData);
    return jsonDifference;
};
exports.jsonDiff = jsonDiff;
