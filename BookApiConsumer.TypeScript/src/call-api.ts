import { BookApiClient } from './book-api-client/bookApiClient'
import * as superAgent from 'superagent';
import { TokenCredentials } from '@azure/ms-rest-js';


async function QueryAuthors() {
    let accessToken;

    try {
        const response = await superAgent.post('http://localhost:5000/connect/token')
            .send('client_id=book-api-consumer&client_secret=secret&grant_type=client_credentials');

        const client = new BookApiClient(new TokenCredentials(response.body.access_token),
            { baseUri: 'http://localhost:5001' });
        const authors = await client.authors.getAll();
        authors.forEach(author => console.log(`Author: ${author.name}`))

    } catch (error) {
        console.log(error);
    }
}

QueryAuthors();
