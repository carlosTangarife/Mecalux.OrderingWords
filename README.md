# Mecalux word ordering!

Generate and deliver us one or more Visual Studio Solutions to Text Process.
The final deliverable should be an UI that user can input order option and text to order plus a button to process the ordering and can also input text do analyze and a button toperform the analysis. Each button should show the result of text process.
The input text will be any text (phrase, a book paragraph, ...) with words separated by a space.

# Technological stack
* Angular (Angular 12, Npm 6.14.13, Node v14.17.1)
* NetCore 5
* Unit Test
* Patter design
* Clean Arquitecture front/back
* Solid
* Clean code
* Dependency injection

# Steps to run the project

## Front
* cd ui/OrderingWords && npm run start

## Back
* cd src/Mecalux.OrderingWords.Api && dotnet run

## Project structure

In both front and back, an attempt was made to use the philosophy of clean architecture.
* Api
* Applications
* Domain
* Infrastructure