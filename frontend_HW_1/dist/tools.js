"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const htmlResources_1 = require("./htmlResources");
const jsonDiff_1 = require("./jsonDiff");
const commander_1 = require("commander");
commander_1.program
    .command('html-resources')
    .description('Search links in HTML and returns an array of links')
    .arguments('<filePath1>')
    .action((filePath1) => __awaiter(void 0, void 0, void 0, function* () { return console.log(yield (0, htmlResources_1.htmlResources)(filePath1)); }));
commander_1.program
    .command('json-diff')
    .description('Сompares json files and return report')
    .arguments('<filePath1> <filePath2>')
    .action((filePath1, filePath2) => __awaiter(void 0, void 0, void 0, function* () { return console.log(JSON.stringify(yield (0, jsonDiff_1.jsonDiff)(filePath1, filePath2), null, 2)); }));
commander_1.program.parse(process.argv);
