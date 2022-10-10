using Books;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
async Task<List<Book>> GetAllBooks(BookContext context) =>
    await context.Books.ToListAsync();

app.MapGet("/", () => "Welcome to Book Store");
app.MapGet("/Books", async (BookContext context) =>
    await context.Books.ToListAsync());

app.MapGet("/Book/{Id}", async (BookContext context, int id) =>
    await context.Books.FindAsync(id) is Book book ?
        Results.Ok(book) :
        Results.NotFound("Sorry, book not found. :/"));

app.MapPost("/Book", async (BookContext context, Book book) =>
{
    context.Books.Add(book);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllBooks(context));
});

app.MapPut("/Book/{Id}", async (BookContext context, Book book, int Id) =>
{
    var dbBook = await context.Books.FindAsync(Id);
    if (dbBook == null) return Results.NotFound("No book found. :/");

    dbBook.Name = book.Name;
    dbBook.Writer = book.Writer;
  
    await context.SaveChangesAsync();

    return Results.Ok(await GetAllBooks(context));
});

app.MapDelete("/Book/{Id}", async (BookContext context, int Id) =>
{
    var dbBook = await context.Books.FindAsync(Id);
    if (dbBook == null) return Results.NotFound("Which book?");

    context.Books.Remove(dbBook);
    await context.SaveChangesAsync();

    return Results.Ok(await GetAllBooks(context));
});
app.Run();
