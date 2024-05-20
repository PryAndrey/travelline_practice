import "./responseBlock.css";

export const ResponseBlock = (buttonColor: string) => {
  return `
  <div class="response">
    <div class="request-title">
      <h4><span>
        Response
        <div class="underline" style="background-color: ${buttonColor}" />
      </span></h4>
    </div>
    <div class="response-body-block">
      <div class="request-url">
        <h4>Request URL</h4>
        <pre class="response-url-data"></pre>
      </div>
      <div class="response-code">
        <h4>Response code</h4>
        <pre class="response-code-data"></pre>
      </div>
      <div class="response-body">
        <h4>Response body</h4>
        <pre class="response-body-data"></pre>
      </div>
      <div class="response-headers">
        <h4>Response headers</h4>
        <pre class="response-headers-data"></pre>
      </div>
    </div>
  </div>`
}