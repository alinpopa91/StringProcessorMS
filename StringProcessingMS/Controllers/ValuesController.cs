using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StringProcessing.BLL.Common;
using StringProcessing.BLL.Contracts;
using StringProcessing.BLL.Services;

namespace StringProcessingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IProcessStringService _processStringService;
        private List<string> _inputStringLines;
        private List<string> _outputStringLines;

        public ValuesController(IProcessStringService processStringService)
        {
            _processStringService = processStringService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _inputStringLines = new List<string>();

            var ret1 = _processStringService.Process("Assda drRRrfa PfffaASDv", Enumerations.Operator.Lowercase);
            var ret2 = _processStringService.Process("EEll ggguur aaa lorEM ipsum dolor", Enumerations.Operator.Invert);
            return new string[] { ret1, ret2 };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // public void Post([FromBody] string value)
        // POST api/values
        [HttpPost]
        public ProcessResponse Post([FromBody] ProcessRequest value)
        {
            var toReturn = new ProcessResponse();
            string inputLine = string.Empty;
            _inputStringLines = new List<string>();
            try
            {
                //if (!System.IO.File.Exists(Path.GetFullPath(value.PathToInput)))
                //{
                //    throw new ArgumentException();
                //}



                using (StreamReader file = new StreamReader(Path.GetFullPath(value.PathToInput)))
                {
                    while ((inputLine = file.ReadLine()) != null)
                    {
                        _inputStringLines.Add(inputLine);
                    }

                    file.Close();
                }

                _outputStringLines = new List<string>();

                List<Enumerations.Operator> requiredOperations = new List<Enumerations.Operator>();
                foreach (var op in value.Operations)
                {
                    switch (op.ToLower())
                    {
                        case "invert":
                            requiredOperations.Add(Enumerations.Operator.Invert);
                            break;
                        case "sort":
                            requiredOperations.Add(Enumerations.Operator.Sort);
                            break;
                        case "uppercase":
                            requiredOperations.Add(Enumerations.Operator.Uppercase);
                            break;
                        case "lowercase":
                            requiredOperations.Add(Enumerations.Operator.Lowercase);
                            break;
                        case "removespaces":
                            requiredOperations.Add(Enumerations.Operator.RemoveSpaces);
                            break;
                    }
                }

                for (int i = 0; i < _inputStringLines.Count; i++)
                {
                    foreach (var op in requiredOperations)
                    {
                        var aux = _inputStringLines[i];
                        aux = _processStringService.Process(_inputStringLines[i], op);
                        _inputStringLines[i] = aux;
                    }

                    _outputStringLines.Add(_inputStringLines[i]);
                }

                var outputFileName = Path.GetFullPath(value.PathToOutput);
                if (System.IO.File.Exists(outputFileName))
                {
                    System.IO.File.Delete(outputFileName);
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFileName, true))
                {
                    foreach (var wr in _outputStringLines)
                    {
                        file.WriteLine(wr);
                    }
                }

            }
            catch (ArgumentException argEx)
            {
                toReturn.Success = false;
                toReturn.Message = argEx.Message;
                toReturn.ErrorType = "File operations";
            }
            catch (Exception ex)
            {
                toReturn.Success = false;
                toReturn.Message = ex.Message;
                toReturn.ErrorType = "Unknowed";
            }
            finally
            {
                if (toReturn.Success)
                {
                    toReturn.Message = "Output file has been generated at " + Path.GetFullPath(value.PathToOutput);
                    toReturn.ErrorType = null;
                }
            }


            return toReturn;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
