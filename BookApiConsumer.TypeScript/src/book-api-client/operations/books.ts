/*
 * Code generated by Microsoft (R) AutoRest Code Generator.
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

import * as msRest from "@azure/ms-rest-js";
import * as Models from "../models";
import * as Mappers from "../models/booksMappers";
import { BookApiClientContext } from "../bookApiClientContext";

/** Class representing a Books. */
export class Books {
  private readonly client: BookApiClientContext;

  /**
   * Create a Books.
   * @param {BookApiClientContext} client Reference to the service client.
   */
  constructor(client: BookApiClientContext) {
    this.client = client;
  }

  /**
   * @summary Get the list of all books
   * @param [options] The optional parameters
   * @returns Promise<Models.BooksGetResponse>
   */
  get(options?: msRest.RequestOptionsBase): Promise<Models.BooksGetResponse>;
  /**
   * @param callback The callback
   */
  get(callback: msRest.ServiceCallback<Models.Book[]>): void;
  /**
   * @param options The optional parameters
   * @param callback The callback
   */
  get(options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.Book[]>): void;
  get(options?: msRest.RequestOptionsBase | msRest.ServiceCallback<Models.Book[]>, callback?: msRest.ServiceCallback<Models.Book[]>): Promise<Models.BooksGetResponse> {
    return this.client.sendOperationRequest(
      {
        options
      },
      getOperationSpec,
      callback) as Promise<Models.BooksGetResponse>;
  }
}

// Operation Specifications
const serializer = new msRest.Serializer(Mappers);
const getOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "Books",
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "Book"
            }
          }
        }
      }
    },
    default: {}
  },
  serializer
};
