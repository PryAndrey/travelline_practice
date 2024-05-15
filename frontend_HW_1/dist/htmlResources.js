"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.htmlResources = void 0;
const node_html_parser_1 = require("node-html-parser");
const fs_1 = __importDefault(require("fs"));
const htmlResources = (filePath) => {
    const htmlRoot = (0, node_html_parser_1.parse)(fs_1.default.readFileSync(filePath, 'utf8'));
    const hrefs = new Set();
    htmlRoot.querySelectorAll('link[href], script[src], img[src], a[href]').forEach((element) => {
        const attribute = element.getAttribute('href') || element.getAttribute('src');
        if (attribute) {
            hrefs.add(attribute);
        }
    });
    console.log(Array.from(hrefs));
};
exports.htmlResources = htmlResources;
