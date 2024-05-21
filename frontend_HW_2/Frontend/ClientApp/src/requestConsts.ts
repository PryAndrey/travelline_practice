export const methodTypes = [`GET`, `POST`, `DELETE`, `PUT`] as const;
export type MethodType = (typeof methodTypes)[number];

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

export type RequestOptions = {
  method: MethodType;
  path: string;
  parameters?: string;
  body?: Record<string, unknown>;
}

export const logicProps: RequestLogicProps[] = [
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

export const htmlProps: RequestProps[] = [
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
