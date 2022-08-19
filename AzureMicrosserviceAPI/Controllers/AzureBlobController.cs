using AzureMicrosserviceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace AzureMicrosserviceAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ExcludeFromCodeCoverage]
    public class AzureBlobController : ControllerBase
    {
        private readonly IAzureBlobService _azureBlobService;

        public AzureBlobController(IAzureBlobService azureBlobService)
        {
            _azureBlobService = azureBlobService;
        }

        /// <summary>
        /// Realiza o upload de uma imagem para o blob private da azure
        /// </summary>
        /// <returns></returns>
        [HttpPost("UploadInPrivateContainer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult> UploadInPrivateContainer()
        {
            var isSuccess = await _azureBlobService.UploadInPrivateContainer();

            if (!isSuccess) return BadRequest();

            return Ok();
        }

        /// <summary>
        /// Realiza o upload de uma imagem para o blob public da azure
        /// </summary>
        /// <returns></returns>
        [HttpPost("UploadInPublicBlobContainer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult> UploadInPublicBlobContainer()
        {
            var isSuccess = await _azureBlobService.UploadInPublicBlobContainer();

            if (!isSuccess) return BadRequest();

            return Ok();
        }
    }
}
