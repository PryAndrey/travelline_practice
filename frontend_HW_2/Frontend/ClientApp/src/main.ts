import arrowIcon from "./icon-arrow-up.svg";
import "./style.css";

const createHtmlNode = (htmlString: string | string[]) => {
  const placeholder = document.createElement("div");
  placeholder.innerHTML = typeof htmlString === `string` ? htmlString : htmlString.join(``);

  return placeholder.firstElementChild;
};

const createHtml = () => {
  return `
<div class="route route-get">
  <div class="route-header">
    <button class="route-summary">
      <div class="route-summary-method">GET</div>
      <span class="route-summary-path">/Users</span>
      <div class="route-summary-arrow"><img class="arrow" src=${arrowIcon} /></div>
    </button>
  </div>
</div>`;
};

(() => {
  const appDiv = document.querySelector<HTMLDivElement>("#app");
  const node = createHtmlNode(createHtml());
  if (appDiv && node) {
    appDiv.append(node);
  }
})();
