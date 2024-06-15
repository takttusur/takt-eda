# Meal plan for short trips service


## Architecture decisions

### Two services

The main workflow is: user starts a meal planning by filling survey, next the service should 
create a meal combinations using meal database and user's survey.

Creating a meal combination is a optimization task, when an optimization function is provided,
and some restrictions are provided. The function has a target, it could be:
* minimize price
* minimize total weight
* etc.

Because, the optimization process cannot be finished in predicted time, it is placed in
separated service.

### Using one DB by both services

Actually, using one DB for several services is not good approach, but the DB has a meals collection.
The meals collection is a table with:
* meal name
* eating time type (breakfast, lunch, dinner)
* how to cook guide
* ingredients

To combine several meals using optimization algorithm we have to have information about all meals.
It could be possible if we create separated db for recipes, but it will increase complexity when
we'll decide to provide meal editor.
So, one db will be created to operate with meal recipes: explore it, use it, edit it. 

