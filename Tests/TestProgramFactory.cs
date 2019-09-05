using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace hackertests.Tests
{
    public class TestProgramFactory
    {
        private readonly IEnumerable<ITestProgram> _programs;

        public TestProgramFactory(IEnumerable<ITestProgram> programs)
        {
            _programs = programs;
        }

        public void ProcessProgram(object name)
        {
            // var allPrograms = _programs.Where(e => e.GetObject() );

            // foreach (var item in allPrograms)
            // {
            //     item.Enrich(name);
            // }
        }

    }
}