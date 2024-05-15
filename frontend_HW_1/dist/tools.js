"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const htmlResources_1 = require("./htmlResources");
const jsonDiff_1 = require("./jsonDiff");
const [, , command, filePath1, filePath2] = process.argv;
if (command === 'html-resources') {
    try {
        (0, htmlResources_1.htmlResources)(filePath1);
    }
    catch (e) {
        console.error('Error processing HTML file:\n', e);
    }
}
else if (command === 'json-diff') {
    try {
        (0, jsonDiff_1.jsonDiff)(filePath1, filePath2);
    }
    catch (e) {
        console.error('Error processing JSON file:\n', e);
    }
}
else {
    console.log('I dont know that command:', command);
}
