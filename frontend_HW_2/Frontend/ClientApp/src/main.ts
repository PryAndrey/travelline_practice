import { RequestBlock, requestLogic } from "./components/RequestBlock/requestBlock";
import { RequestLogicProps, RequestProps, htmlProps, logicProps } from "./requestConsts";
import "./style.css";

const createHtmlNode = (htmlString: string | string[]) => {
  const placeholder = document.createElement("div");
  placeholder.innerHTML = typeof htmlString === `string` ? htmlString : htmlString.join(``);

  return placeholder.firstElementChild;
};

const createHtml = (htmlProps: RequestProps[], logicProps: RequestLogicProps[]) => {
  return `
  <div class="requests-wrapper">
    ${htmlProps.map((prop, index) => RequestBlock(prop, logicProps[index].cssClass)).join('')}
  </div>
  `;
};

(() => {
  const appDiv = document.querySelector<HTMLDivElement>("#app");
  const node = createHtmlNode(createHtml(htmlProps, logicProps));

  if (appDiv && node) {
    appDiv.append(node);
    logicProps.map(props => requestLogic(appDiv, props));
  }
})();

