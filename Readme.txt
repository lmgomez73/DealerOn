Hi! 

I'm Leandro and this is my Code Challenge for you!

I used my knowledge in Api's to build this challenge. I tried to do it the most maintanable and scalable possible for me. 
I used the SOLID principles to handle variety of product types and MemoryCache to store the data. As I use the repository patter we can easily add a database without 
change the functionalities of the application. I also used FactoryPattern to solve the creational problem with different product types.


There's already a seeder to add the products mentioned in the challenge explaination. They are added in the same order with an autoincrement Id

-------------------------------------------------------------------------------------------------------

Instructions:

You can add as many entries as your memory computer allows.

To add a new product you can use the swagger page or just make a post action on Postman.


Example: 
url: https://localhost:7124/api/Products
Method: Post
Body (Json):
{
  "name": "Book",
  "price": 12.49,
  "imported": false,
  "productType": 2
}


To create a new sale you have to send and array of productsIds that represents the products on that sale

Example:
url: https://localhost:7124/api/Sales
Method: Post
Body(Json):
{
  "productsIds": [
    1, //book
    1, //book again
    2, //music CD
    3  //Chocolate bar
  ]
}

This will return a string with the data with asked format


You can check all the productsIds on ProductsApi with Get action, it will return the entire list of saved products.

Consider that as this is a coding challenge there's no guarantee that this will work for all use cases because I could keep coding and adding things forever.

For example, I did not handle the multithread issue while accesing and modifying the memory cache. So if you try this with javascript, It won't work. 
(yeah, I tried to make it work with a js file to test but I had to use a seeder :) )

I hope you like it and I hope to discuss more about it in a call :)


Regards

Leandro Gomez
