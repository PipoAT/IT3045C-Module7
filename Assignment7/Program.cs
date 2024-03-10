using System.Runtime.CompilerServices;
using Assignment7.Database;
using Assignment7.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonDbContext>(options =>
{
    options.UseInMemoryDatabase("People.db");
});

var app = builder.Build();

app.Urls.Add("http://localhost:5555");

app.MapGet("/", () => {

return "Hello World!";

});

app.MapGet("/people", async (PersonDbContext dbContext) =>
{
    return await dbContext.People.ToListAsync();
});

app.MapGet("/people/{personID}", async (int personID, PersonDbContext dbContext) =>
    await dbContext.People.FindAsync(personID)
    is Person person
    ? Results.Ok(person)
    : Results.NotFound());


app.MapPost("/people", async (Person person, PersonDbContext dbContext) =>
{
    dbContext.People.Add(person);
    await dbContext.SaveChangesAsync();

    return person;
    //return Results.Created($"/people/{person.PersonID}", person);
});

app.MapPut("/people", async (Person person, PersonDbContext dbContext) =>
{
    dbContext.People.Update(person);
    await dbContext.SaveChangesAsync();

    return person;
    //return Results.Created($"/people/{person.PersonID}", person);
});

app.Run();
