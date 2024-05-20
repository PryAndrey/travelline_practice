export const methodTypes = [`GET`, `POST`, `DELETE`, `PUT`] as const;
export type MethodType = (typeof methodTypes)[number];

type RequestOptions = {
  method: MethodType;
  path: string;
  parameters?: string;
  body?: Record<string, unknown>;
}

export const fetchResponse = async ({ method, path, parameters, body }: RequestOptions) => {
  return fetch(`http://localhost:5154${path}/${parameters ?? ``}`,
    {
      method,
      ...(
        body ? {
          headers: {
            "Content-Type": "application/json;charset=utf-8",
          },
          body: JSON.stringify(body)
        } : {}
      )
    }
  )
}