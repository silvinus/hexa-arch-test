using HexaArch.Application.Commands.RegisterContract;
using HexaArch.Application.Queries;
using HexaArch.Server.Extensions;
using HexaArch.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace HexaArch.Server.Controllers.Register
{

    [Route("api/[controller]")]
    public class InterventionController: Controller
    {
        public readonly IRegisterUseCase register;
        public readonly IInterventionQueries queries;

        public InterventionController(IRegisterUseCase register, IInterventionQueries queries)
        {
            this.register = register;
            this.queries = queries;
        }

        /// <summary>
        /// Register a new Intervention
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InterventionRequest request)
        {
            RegisterResults registerResults = await register.Execute(
                                                        new Domain.ValueObject.Supplier(request.Supplier),
                                                        request.ContractName,
                                                        request.InterventionDate,
                                                        request.Price,
                                                        request.Tva);

            RegisterModel model = new RegisterModel(
                registerResults.LastIntervention.Id,
                registerResults.LastIntervention.InterventionDate,
                registerResults.LastIntervention.Price,
                registerResults.LastIntervention.Tva,
                registerResults.Contract.InterventionCount,
                registerResults.Contract.Name
                );

            return CreatedAtRoute("GetInterventionById", new { Id = model.InterventionId }, model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Application.Results.InterventionResult> interventions = await queries.GetInterventions();
            return Ok(interventions.Select(w => w.ToInterventionModel()));
        }

        [HttpGet("{Id}", Name = "GetInterventionById")]
        public async Task<IActionResult> Get(Guid Id)
        {
            Application.Results.InterventionResult interventions = await queries.GetIntervention(Id);
            return Ok(interventions.ToInterventionModel());
        }
    }
}
