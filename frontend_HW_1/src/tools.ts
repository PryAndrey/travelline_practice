import { htmlResources } from './htmlResources';
import { jsonDiff } from './jsonDiff';
import { program } from 'commander';

program
  .command('html-resources')
  .description('Search links in HTML and returns an array of links')
  .arguments('<filePath1>')
  .action(async (filePath1: string) => console.log(await htmlResources(filePath1)));

program
  .command('json-diff')
  .description('Сompares json files and return report')
  .arguments('<filePath1> <filePath2>')
  .action(async (filePath1: string, filePath2: string) =>
    console.log(JSON.stringify(await jsonDiff(filePath1, filePath2), null, 2)));

program.parse(process.argv);