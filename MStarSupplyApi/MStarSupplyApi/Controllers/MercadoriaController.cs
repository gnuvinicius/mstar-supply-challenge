using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MStarSupply.Models.Enums;
using MStarSupply.Models.Models;
using MStarSupply.Services.Services;
using MStarSupplyApi.Dtos;

namespace MStarSupplyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MercadoriaController : ControllerBase
    {
        private IMercadoriaService _service;

        private IMapper _mapper;

        public MercadoriaController(IMercadoriaService mercadoriaService, IMapper mapper)
        {
            this._service = mercadoriaService;
            this._mapper = mapper;
        }

        [HttpGet("ListaMercadorias")]
        public async Task<ActionResult<IList<MercadoriaDto>>> ListaMercadorias()
        {
            var result = _mapper.Map<IList<MercadoriaDto>>(await _service.ListaMercadorias());
            return Ok(result);
        }

        [HttpGet("ListaFabricantes")]
        public async Task<ActionResult<FabricanteDto>> ListaFabricantes()
        {
            var result = _mapper.Map<IEnumerable<FabricanteDto>>(await _service.ListaFabricantes());
            return Ok(result);
        }

        [HttpPost("CadastraFabricante")]
        public async Task<IActionResult> CadastraFabricante(FabricanteRequestDto dto)
        {
            await _service.CadastraFabricante(_mapper.Map<Fabricante>(dto));
            return Ok();
        }

        [HttpPost("CadastraMercadoria")]
        public async Task<IActionResult> CadastraMercadoria(MercadoriaRequestDto dto)
        {
            await _service.CadastraMercadoria(_mapper.Map<Mercadoria>(dto));
            return Ok();
        }

        [HttpPost("RegistraEntradaSaidaMercadoria")]
        public IActionResult RegistraEntradaSaidaMercadoria(EntradaSaidaRequestDto dto)
        {
            _service.RegistraEntradaSaidaMercadoria(_mapper.Map<EntradaSaida>(dto));
            return Ok();
        }

        [HttpGet("ListaEntradasSaida")]
        public async Task<ActionResult<EntradaSaidaDto>> ListaEntradasSaida()
        {
            var result = await _service.ListaEntradasSaida();

            return Ok(_mapper.Map<IEnumerable<EntradaSaidaDto>>(result));
        }

        [HttpGet("ListaEntradasSaidaPorMercadoria")]
        public async Task<ActionResult<IEnumerable<EntradaSaidaDto>>> ListaEntradasSaidaPorMercadoria(Guid mercadoriaId, EntradaSaidaEnum tipo)
        {
            var result = await _service.ListaEntradasSaidaPorMercadoria(mercadoriaId, tipo);
            
            return Ok(_mapper.Map<IEnumerable<EntradaSaidaDto>>(result));
        }

        [HttpGet("QuantidadeDisponivelPorMercadoria")]
        public ActionResult<int> QuantidadeDisponivelPorMercadoria(Guid mercadoriaId)
        {
            var result = _service.QuantidadeDisponivelPorMercadoria(mercadoriaId);

            return Ok(result);
        }

    }
}