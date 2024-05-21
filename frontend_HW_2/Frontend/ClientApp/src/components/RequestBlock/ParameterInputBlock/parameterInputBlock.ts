import "./parameterInputBlock.css";

export const ParameterInputBlock = (inputParameterTemplate: string) => {
  return `
  <div class="parameter-block">
    <div class="parameter-title">
      <div class="parameter-name">
        ${inputParameterTemplate}
        <span>&nbsp;*</span>
      </div>
      <span class="parameter-type">${inputParameterTemplate === "id" ? "int" : "string"}</span>
    </div>
    <input type="text" class="parameter-input" placeholder="${inputParameterTemplate}"></input>
  </div>
  `
}