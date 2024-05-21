import { RequestOptions } from "./requestConsts"

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