(function(){const t=document.createElement("link").relList;if(t&&t.supports&&t.supports("modulepreload"))return;for(const e of document.querySelectorAll('link[rel="modulepreload"]'))a(e);new MutationObserver(e=>{for(const o of e)if(o.type==="childList")for(const c of o.addedNodes)c.tagName==="LINK"&&c.rel==="modulepreload"&&a(c)}).observe(document,{childList:!0,subtree:!0});function n(e){const o={};return e.integrity&&(o.integrity=e.integrity),e.referrerPolicy&&(o.referrerPolicy=e.referrerPolicy),e.crossOrigin==="use-credentials"?o.credentials="include":e.crossOrigin==="anonymous"?o.credentials="omit":o.credentials="same-origin",o}function a(e){if(e.ep)return;e.ep=!0;const o=n(e);fetch(e.href,o)}})();const U="data:image/svg+xml,%3csvg%20xmlns='http://www.w3.org/2000/svg'%20width='20'%20height='20'%20viewBox='0%200%2020%2020'%3e%3cpath%20d='M%2017.418%2014.908%20C%2017.69%2015.176%2018.127%2015.176%2018.397%2014.908%20C%2018.667%2014.64%2018.668%2014.207%2018.397%2013.939%20L%2010.489%206.109%20C%2010.219%205.841%209.782%205.841%209.51%206.109%20L%201.602%2013.939%20C%201.332%2014.207%201.332%2014.64%201.602%2014.908%20C%201.873%2015.176%202.311%2015.176%202.581%2014.908%20L%2010%207.767%20L%2017.418%2014.908%20Z'%3e%3c/path%3e%3c/svg%3e",w=async({method:s,path:t,parameters:n,body:a})=>fetch(`http://localhost:5154${t}/${n??""}`,{method:s,...a?{headers:{"Content-Type":"application/json;charset=utf-8"},body:JSON.stringify(a)}:{}}),k=s=>`
  <div class="parameter-block">
    <div class="parameter-title">
      <div class="parameter-name">
        ${s}
        <span>&nbsp;*</span>
      </div>
      <span class="parameter-type">${s==="id"?"int":"string"}</span>
    </div>
    <input type="text" class="parameter-input" placeholder="${s}"></input>
  </div>
  `,P=(s,t)=>`
    <div class="request-title">
      <h4><span>
        Request body
        <div class="underline" style="background-color: ${s}" />
      </span></h4>
    </div>
    <textarea type="text" class="body-input">${t}
    </textarea>
  `,x=s=>`
  <div class="response">
    <div class="request-title">
      <h4><span>
        Response
        <div class="underline" style="background-color: ${s}" />
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
  </div>`,O=({method:s,path:t,backgroundColor:n,buttonColor:a,inputParameterTemplate:e,inputBodyTemplate:o},c)=>`
  <div class="${c}">
    <div class="request-header">
      <button class="request-header_drop-button" style="background-color: ${n};">
        <div class="request-header_method" style="background-color: ${a};">${s}</div>
          <span class="request-header_path">${t}</span>
        <div class="request-header_arrow"><img class="arrow" src=${U} /></div>
      </button>
    </div>
    <div class="request-body">
      <div class="request-title">
        <h4><span>
          Parameters
          <div class="underline" style="background-color: ${a}"/>
        </span></h4>
      </div>
      ${t!=="/Users"?k(e??""):""}
      ${s==="PUT"||s==="POST"?P(a,o??""):""}
      <div class="execute-buttons-wrapper">
        <button class="executor">Execute</button>
        <button class="clear">Clear</button>
      </div>
      ${x(a)}
    </div>
  </div>`,u=(s,{method:t,path:n,cssClass:a})=>{const e=s.querySelector("."+a),o=e==null?void 0:e.querySelector(".request-header_drop-button"),c=e==null?void 0:e.querySelector(".arrow"),g=e==null?void 0:e.querySelector(".request-body"),l=e==null?void 0:e.querySelector(".parameter-input"),v=e==null?void 0:e.querySelector(".body-input"),p=e==null?void 0:e.querySelector(".executor"),r=e==null?void 0:e.querySelector(".clear"),d=e==null?void 0:e.querySelector(".response"),h=e==null?void 0:e.querySelector(".response-url-data"),m=e==null?void 0:e.querySelector(".response-code-data"),y=e==null?void 0:e.querySelector(".response-body-data"),f=e==null?void 0:e.querySelector(".response-headers-data"),L=()=>{h&&(h.innerHTML=""),m&&(m.innerHTML=""),y&&(y.innerHTML=""),f&&(f.innerHTML="")};o==null||o.addEventListener("click",()=>{g==null||g.classList.toggle("open"),c==null||c.classList.toggle("up")}),p==null||p.addEventListener("click",()=>{l?l!=null&&l.value&&(d==null||d.classList.add("open"),r==null||r.classList.add("open")):(d==null||d.classList.add("open"),r==null||r.classList.add("open"))}),r==null||r.addEventListener("click",()=>{d==null||d.classList.remove("open"),r==null||r.classList.remove("open"),L()}),p==null||p.addEventListener("click",async()=>{const $=l==null?void 0:l.value,T=v==null?void 0:v.value,b=await w({method:t,path:n,parameters:$,body:T?JSON.parse(T):void 0}),E=await b.json();L(),h==null||h.append(b.url),m==null||m.append(b.status.toString()," ",b.statusText),y==null||y.append(JSON.stringify(E,null,2)),b.headers.forEach((S,C)=>{f==null||f.append(`${C}: ${S}
`)})})},N=s=>{const t=document.createElement("div");return t.innerHTML=typeof s=="string"?s:s.join(""),t.firstElementChild},R=(s,t)=>`
  <div class="requests-wrapper">
    ${s.map((n,a)=>O(n,t[a].cssClass)).join("")}
  </div>
  `,i=[{method:"GET",path:"/Users",cssClass:"get-all-block"},{method:"POST",path:"/Users",cssClass:"post-block"},{method:"GET",path:"/Users",cssClass:"get-by-id-block"},{method:"PUT",path:"/Users",cssClass:"put-block"},{method:"DELETE",path:"/Users",cssClass:"delete-block"},{method:"GET",path:"/Users/get-by-email",cssClass:"get-by-email-block"}],G=`
{
  "firstName": "string",
  "lastName": "string",
  "email": "user@example.com",
  "role": 1
}`,_=`
{
  "firstName": "string",
  "lastName": "string",
  "role": 1
}`,j=[{method:"GET",path:"/Users",backgroundColor:"inherit",buttonColor:"#61affe"},{method:"POST",path:"/Users",backgroundColor:"#e8f6f0",buttonColor:"#49cc90",inputBodyTemplate:G},{method:"GET",path:"/Users/{id}",backgroundColor:"inherit",buttonColor:"#61affe",inputParameterTemplate:"id"},{method:"PUT",path:"/Users/{id}",backgroundColor:"#fbf1e6",buttonColor:"#fca130",inputParameterTemplate:"id",inputBodyTemplate:_},{method:"DELETE",path:"/Users/{id}",backgroundColor:"#fae7e7",buttonColor:"#f93e3e",inputParameterTemplate:"id"},{method:"GET",path:"/Users/get-by-email/{email}",backgroundColor:"inherit",buttonColor:"#61affe",inputParameterTemplate:"email"}];(()=>{const s=document.querySelector("#app"),t=N(R(j,i));s&&t&&(s.append(t),u(s,i[0]),u(s,i[1]),u(s,i[2]),u(s,i[3]),u(s,i[4]),u(s,i[5]))})();
