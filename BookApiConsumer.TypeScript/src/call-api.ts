import { BookApiClient } from './book-api-client/bookApiClient'

async function QueryAuthors() {
    const client = new BookApiClient({ baseUri: 'http://localhost:5000' });
    const authors = await client.authors.getAll();
    authors.forEach(author => console.log(`Author: ${author.name}`))
}

QueryAuthors();