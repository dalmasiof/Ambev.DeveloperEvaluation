# Developer Evaluation Project

`READ CAREFULLY`

# Developer Comments

## Estructure
The project have a CQRS microservice, with DDD and multyple Contexts behavior. Also include the pattern mediator with the lib MediatR to sync the Handler with the specific Command and Result.
The ORM used is EntityFramework.
The Validation is based on Fluent Validation.
The develop process was made With GitFLow, creating a branch of develop, a branch for the SalesFeature and merging on develop after completed.

## The Idea
Create 2 other contexts(Products and Sales) and create sales based on the products lists. 
Isolating the DB of products from the sales using external identities with denormalizations.
Create a front-end to integrate with the Service using Angularv16 + Material design lib.
Use Reactive forms, Guards, Router and Observables to create a complete flow of Auth the user, Search products, Create Sale and View Sale.

## The Result
My test, unfortunately it is incomplete, missing the front and creating everything on docker.
I've got problems on MediatR to find the handles, so it is not working the API too.
