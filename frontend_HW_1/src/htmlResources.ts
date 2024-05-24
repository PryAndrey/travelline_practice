import { parse } from 'node-html-parser';
import fs from 'fs';

export const htmlResources = (filePath: string) => {
  const htmlRoot = parse(fs.readFileSync(filePath, 'utf8'));

  const hrefs = htmlRoot.querySelectorAll('link[href], script[src], img[src], a[href]')
    .reduce((set, element) => {
      const attribute = element.getAttribute('href') || element.getAttribute('src');
      if (attribute) {
        set.add(attribute);
      }
      return set;
    }, new Set<string>())

  return Array.from(hrefs);
};