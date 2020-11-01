﻿namespace ClothingStore.Server.Features
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
