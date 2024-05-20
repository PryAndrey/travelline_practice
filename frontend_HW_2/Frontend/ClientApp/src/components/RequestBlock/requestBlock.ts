import arrowIcon from "./../../icon-arrow-up.svg";
import { fetchResponse, MethodType } from "../../fetchRequest";
import "./requestBlock.css";
import { ParameterInputBlock } from "./ParameterInputBlock/parameterInputBlock";
import { bodyInputBlock } from "./BodyInputBlock/bodyInputBlock";
import { ResponseBlock } from "./ResponseBlock/responseBlock";

export type RequestProps = {
  method: MethodType;
  path: string;
  backgroundColor: string;
  buttonColor: string;
  inputParameterTemplate?: string;
  inputBodyTemplate?: string;
}

export type RequestLogicProps = {
  method: MethodType;
  path: string;
  cssClass: string;
}

export const RequestBlock = ({ method, path, backgroundColor, buttonColor, inputParameterTemplate, inputBodyTemplate }: RequestProps, cssClass: string) => {
  return `
  <div class="${cssClass}">
    <div class="request-header">
      <button class="request-header_drop-button" style="background-color: ${backgroundColor};">
        <div class="request-header_method" style="background-color: ${buttonColor};">${method}</div>
          <span class="request-header_path">${path}</span>
        <div class="request-header_arrow"><img class="arrow" src=${arrowIcon} /></div>
      </button>
    </div>
    <div class="request-body">
      <div class="request-title">
        <h4><span>
          Parameters
          <div class="underline" style="background-color: ${buttonColor}"/>
        </span></h4>
      </div>
      ${(path !== "/Users") ? ParameterInputBlock(inputParameterTemplate ?? "") : ""}
      ${(method === "PUT" || method === "POST") ? bodyInputBlock(buttonColor, inputBodyTemplate ?? "") : ""}
      <div class="execute-buttons-wrapper">
        <button class="executor">Execute</button>
        <button class="clear">Clear</button>
      </div>
      ${ResponseBlock(buttonColor)}
    </div>
  </div>`
}

export const requestLogic = (appDiv: HTMLDivElement, { method, path, cssClass }: RequestLogicProps) => {

  const requestDiv = appDiv.querySelector<HTMLDivElement>("." + cssClass);

  const headerButton = requestDiv?.querySelector<HTMLButtonElement>(`.request-header_drop-button`);
  const requestArrow = requestDiv?.querySelector(`.arrow`)
  const requestBody = requestDiv?.querySelector(`.request-body`)
  const requestParameterInput = requestDiv?.querySelector<HTMLInputElement>(`.parameter-input`)
  const requestBodyInput = requestDiv?.querySelector<HTMLInputElement>(`.body-input`)

  const requestExecutor = requestDiv?.querySelector<HTMLButtonElement>(`.executor`)
  const requestClear = requestDiv?.querySelector<HTMLButtonElement>(`.clear`)
  const responseBlock = requestDiv?.querySelector<HTMLDivElement>(`.response`)

  const responseUrlHTMLBlock = requestDiv?.querySelector(`.response-url-data`)
  const responseCodeHTMLBlock = requestDiv?.querySelector(`.response-code-data`)
  const responseBodyHTMLBlock = requestDiv?.querySelector(`.response-body-data`)
  const responseHeadersHTMLBlock = requestDiv?.querySelector(`.response-headers-data`)

  const nullificationResponse = () => {
    if (responseUrlHTMLBlock)
      responseUrlHTMLBlock.innerHTML = "";
    if (responseCodeHTMLBlock)
      responseCodeHTMLBlock.innerHTML = "";
    if (responseBodyHTMLBlock)
      responseBodyHTMLBlock.innerHTML = "";
    if (responseHeadersHTMLBlock)
      responseHeadersHTMLBlock.innerHTML = "";
  }

  headerButton?.addEventListener("click", () => {
    requestBody?.classList.toggle(`open`);
    requestArrow?.classList.toggle(`up`);
  })

  requestExecutor?.addEventListener("click", () => {
    if (!requestParameterInput) {
      responseBlock?.classList.add(`open`);
      requestClear?.classList.add(`open`);
    } else if (requestParameterInput?.value) {
      responseBlock?.classList.add(`open`);
      requestClear?.classList.add(`open`);
    }
  })

  requestClear?.addEventListener("click", () => {
    responseBlock?.classList.remove(`open`);
    requestClear?.classList.remove(`open`);
    nullificationResponse();
  })

  requestExecutor?.addEventListener("click", async () => {
    const parameter = requestParameterInput?.value;
    const body = requestBodyInput?.value;

    const response = await fetchResponse({
      method: method,
      path: path,
      parameters: parameter,
      body: body ? JSON.parse(body) : undefined
    })
    const responseBody = await response.json();

    nullificationResponse();
    responseUrlHTMLBlock?.append(response.url);
    responseCodeHTMLBlock?.append(response.status.toString(), " ", response.statusText);
    responseBodyHTMLBlock?.append(JSON.stringify(responseBody, null, 2));
    response.headers.forEach((value, key) => {
      responseHeadersHTMLBlock?.append(`${key}: ${value}\n`);
    });
  })
};