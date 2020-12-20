/*
 * Code generated by Microsoft (R) AutoRest Code Generator.
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

import * as msRest from "@azure/ms-rest-js";
import * as Models from "../models";
import * as Mappers from "../models/authorsMappers";
import * as Parameters from "../models/parameters";
import { BookApiClientContext } from "../bookApiClientContext";

/** Class representing a Authors. */
export class Authors {
  private readonly client: BookApiClientContext;

  /**
   * Create a Authors.
   * @param {BookApiClientContext} client Reference to the service client.
   */
  constructor(client: BookApiClientContext) {
    this.client = client;
  }

  /**
   * @param [options] The optional parameters
   * @returns Promise<Models.AuthorsGetAllResponse>
   */
  getAll(options?: msRest.RequestOptionsBase): Promise<Models.AuthorsGetAllResponse>;
  /**
   * @param callback The callback
   */
  getAll(callback: msRest.ServiceCallback<Models.Author[]>): void;
  /**
   * @param options The optional parameters
   * @param callback The callback
   */
  getAll(options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.Author[]>): void;
  getAll(options?: msRest.RequestOptionsBase | msRest.ServiceCallback<Models.Author[]>, callback?: msRest.ServiceCallback<Models.Author[]>): Promise<Models.AuthorsGetAllResponse> {
    return this.client.sendOperationRequest(
      {
        options
      },
      getAllOperationSpec,
      callback) as Promise<Models.AuthorsGetAllResponse>;
  }

  /**
   * @param [options] The optional parameters
   * @returns Promise<Models.AuthorsAddAuthorResponse>
   */
  addAuthor(options?: Models.AuthorsAddAuthorOptionalParams): Promise<Models.AuthorsAddAuthorResponse>;
  /**
   * @param callback The callback
   */
  addAuthor(callback: msRest.ServiceCallback<Models.Author>): void;
  /**
   * @param options The optional parameters
   * @param callback The callback
   */
  addAuthor(options: Models.AuthorsAddAuthorOptionalParams, callback: msRest.ServiceCallback<Models.Author>): void;
  addAuthor(options?: Models.AuthorsAddAuthorOptionalParams | msRest.ServiceCallback<Models.Author>, callback?: msRest.ServiceCallback<Models.Author>): Promise<Models.AuthorsAddAuthorResponse> {
    return this.client.sendOperationRequest(
      {
        options
      },
      addAuthorOperationSpec,
      callback) as Promise<Models.AuthorsAddAuthorResponse>;
  }

  /**
   * @param id
   * @param [options] The optional parameters
   * @returns Promise<Models.AuthorsGetResponse>
   */
  get(id: number, options?: msRest.RequestOptionsBase): Promise<Models.AuthorsGetResponse>;
  /**
   * @param id
   * @param callback The callback
   */
  get(id: number, callback: msRest.ServiceCallback<Models.Author>): void;
  /**
   * @param id
   * @param options The optional parameters
   * @param callback The callback
   */
  get(id: number, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.Author>): void;
  get(id: number, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<Models.Author>, callback?: msRest.ServiceCallback<Models.Author>): Promise<Models.AuthorsGetResponse> {
    return this.client.sendOperationRequest(
      {
        id,
        options
      },
      getOperationSpec,
      callback) as Promise<Models.AuthorsGetResponse>;
  }
}

// Operation Specifications
const serializer = new msRest.Serializer(Mappers);
const getAllOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "Authors",
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "Author"
            }
          }
        }
      }
    },
    default: {}
  },
  serializer
};

const addAuthorOperationSpec: msRest.OperationSpec = {
  httpMethod: "POST",
  path: "Authors",
  requestBody: {
    parameterPath: [
      "options",
      "body"
    ],
    mapper: Mappers.Author
  },
  responses: {
    200: {
      bodyMapper: Mappers.Author
    },
    default: {}
  },
  serializer
};

const getOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "Authors/{id}",
  urlParameters: [
    Parameters.id
  ],
  responses: {
    200: {
      bodyMapper: Mappers.Author
    },
    default: {}
  },
  serializer
};
