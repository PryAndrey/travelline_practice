import { RequestBlock, RequestLogicProps, RequestProps, requestLogic } from "./components/RequestBlock/requestBlock";
import "./style.css";

const createHtmlNode = (htmlString: string | string[]) => {
  const placeholder = document.createElement("div");
  placeholder.innerHTML = typeof htmlString === `string` ? htmlString : htmlString.join(``);

  return placeholder.firstElementChild;
};

const createHtml = (htmlProps: RequestProps[], logicProps: RequestLogicProps[]) => {
  return `
  <div class="requests-wrapper">
    ${RequestBlock(htmlProps[0], logicProps[0].cssClass)}
    ${RequestBlock(htmlProps[1], logicProps[1].cssClass)}
    ${RequestBlock(htmlProps[2], logicProps[2].cssClass)}
    ${RequestBlock(htmlProps[3], logicProps[3].cssClass)}
    ${RequestBlock(htmlProps[4], logicProps[4].cssClass)}
    ${RequestBlock(htmlProps[5], logicProps[5].cssClass)}
  </div>
  `;
};


const logicProps: RequestLogicProps[] = [
  {
    method: "GET",
    path: "/Users",
    cssClass: "get-all-block"
  },
  {
    method: "POST",
    path: "/Users",
    cssClass: "post-block"
  },
  {
    method: "GET",
    path: "/Users",
    cssClass: "get-by-id-block"
  },
  {
    method: "PUT",
    path: "/Users",
    cssClass: "put-block"
  },
  {
    method: "DELETE",
    path: "/Users",
    cssClass: "delete-block"
  },
  {
    method: "GET",
    path: "/Users/get-by-email",
    cssClass: "get-by-email-block"
  }
];

const postBodyExample = `
{
  "firstName": "string",
  "lastName": "string",
  "email": "user@example.com",
  "role": 1
}`;

const putBodyExample = `
{
  "firstName": "string",
  "lastName": "string",
  "role": 1
}`;

const htmlProps: RequestProps[] = [
  {
    method: "GET",
    path: "/Users",
    backgroundColor: "inherit",
    buttonColor: "#61affe"
  },
  {
    method: "POST",
    path: "/Users",
    backgroundColor: "#e8f6f0",
    buttonColor: "#49cc90",
    inputBodyTemplate: postBodyExample
  },
  {
    method: "GET",
    path: "/Users/{id}",
    backgroundColor: "inherit",
    buttonColor: "#61affe",
    inputParameterTemplate: "id"
  },
  {
    method: "PUT",
    path: "/Users/{id}",
    backgroundColor: "#fbf1e6",
    buttonColor: "#fca130",
    inputParameterTemplate: "id",
    inputBodyTemplate: putBodyExample
  },
  {
    method: "DELETE",
    path: "/Users/{id}",
    backgroundColor: "#fae7e7",
    buttonColor: "#f93e3e",
    inputParameterTemplate: "id"
  },
  {
    method: "GET",
    path: "/Users/get-by-email/{email}",
    backgroundColor: "inherit",
    buttonColor: "#61affe",
    inputParameterTemplate: "email"
  }
];

(() => {
  const appDiv = document.querySelector<HTMLDivElement>("#app");
  const node = createHtmlNode(createHtml(htmlProps, logicProps));

  if (appDiv && node) {
    appDiv.append(node);
    requestLogic(appDiv, logicProps[0]);
    requestLogic(appDiv, logicProps[1]);
    requestLogic(appDiv, logicProps[2]);
    requestLogic(appDiv, logicProps[3]);
    requestLogic(appDiv, logicProps[4]);
    requestLogic(appDiv, logicProps[5]);
  }
})();

