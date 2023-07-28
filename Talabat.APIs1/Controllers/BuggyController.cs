using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using Talabat.APIs1.Errors;
using Talabat.Service.Data;

public class BuggyController : ControllerBase


{
    private StoreDbConetxt context;

    public BuggyController(StoreDbConetxt context)
    {
        this.context = context;
    }


    // Action that returns a 404 Not Found response

    [HttpGet("notfound")]

    public IActionResult NotFoundError()
    {
     
        return NotFound(new ApiErrorResponse(404));
    }

    // Action that returns a server error excptions
    [HttpGet("servererror")]
    public IActionResult ServerError()
    {
        var products = context.Products.FindAsync(100);
        return Ok(products);
    }

    // Action that returns a bad Request
    [HttpGet("badrequest")]
    public IActionResult GetBadActionResult()
    {
        return BadRequest(new ApiErrorResponse( 
            400));
    }

    [HttpGet("validationerror/{id}")]
    public IActionResult GetValidationError(int id)
    {
        return Ok(new { id });

    }







}
