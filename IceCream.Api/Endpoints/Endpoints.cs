﻿using IceCream.Api.Services;
using IceCream.Shared.Dtos;

namespace IceCream.Api.Endpoints;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/signup",
            async (SignupRequestDto dto, AuthService authService) =>
                TypedResults.Ok(await authService.SignupAsync(dto)));

        app.MapPost("/api/signin",
            async (SigninRequestDto dto, AuthService authService) =>
                TypedResults.Ok(await authService.SigninAsync(dto)));

        app.MapGet("/api/icecreams",
            async (IcecreamService icecreamService) =>
                TypedResults.Ok(await icecreamService.GetIcecreamsAsync()));

        return app;
    }
}
