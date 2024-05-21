import { parse } from 'node-html-parser';
import fs from 'fs';

export const htmlResources = (filePath: string) => {
  const htmlRoot = parse(fs.readFileSync(filePath, 'utf8'));
  const hrefs = new Set<string>();

  htmlRoot.querySelectorAll('link[href], script[src], img[src], a[href]').map((element) => {
    const attribute = element.getAttribute('href') || element.getAttribute('src');
    if (attribute) {
      hrefs.add(attribute);
    }
  });
  return Array.from(hrefs);
};