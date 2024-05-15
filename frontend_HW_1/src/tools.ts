import { htmlResources } from './htmlResources';
import { jsonDiff } from './jsonDiff';

const [, , command, filePath1, filePath2] = process.argv;

if (command === 'html-resources') {
  try {
    htmlResources(filePath1);
  } catch (e) {
    console.error('Error processing HTML file:\n', e);
  }
} else if (command === 'json-diff') {
  try {
    jsonDiff(filePath1, filePath2);
  } catch (e) {
    console.error('Error processing JSON file:\n', e);
  }
} else {
  console.log('I dont know that command:', command);
}
