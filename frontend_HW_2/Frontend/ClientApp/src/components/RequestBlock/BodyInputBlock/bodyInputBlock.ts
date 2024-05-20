import "./bodyInputBlock.css";

export const bodyInputBlock = (buttonColor: string, inputBodyTemplate: string) => {
  return `
    <div class="request-title">
      <h4><span>
        Request body
        <div class="underline" style="background-color: ${buttonColor}" />
      </span></h4>
    </div>
    <textarea type="text" class="body-input">${inputBodyTemplate}
    </textarea>
  `
}