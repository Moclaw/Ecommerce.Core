using EfCore.Repositories;
using Microsoft.Extensions.Logging;
using Ecom.Core.Infrastructure.Persistence.EfCore;

namespace Ecom.Core.Infrastructure.Repositories;

public class CommandDefaultRepository(ApplicationDbContext dbContext, ILogger<CommandDefaultRepository> logger)
    : CommandRepository(dbContext, logger)
{ }
