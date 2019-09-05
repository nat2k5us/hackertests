using System;
using NetSpell.SpellChecker;

namespace hackertests.Tests
{
    public class DictionaryWords : ITestProgram
    {
        Spelling SpellChecker;
        public DictionaryWords()
        {
            this.SpellChecker = new Spelling();

            this.SpellChecker.MisspelledWord += (SpellChecker_MisspelledWord);
            this.SpellChecker.EndOfText += (SpellChecker_EndOfText);
            this.SpellChecker.DoubledWord += (SpellChecker_DoubledWord);
        }

        private void SpellChecker_DoubledWord(object sender, SpellingEventArgs args)
        {
            // // update text  
            // Document.Text = SpellChecker.Text;
            System.Console.WriteLine($"Double Word {SpellChecker.Text}");
        }

        private void SpellChecker_EndOfText(object sender, EventArgs args)
        {
            // update text  
            // Document.Text = SpellChecker.Text;
            System.Console.WriteLine($"EndofText Word {SpellChecker.Text}");
        }

        private void SpellChecker_MisspelledWord(object sender, SpellingEventArgs args)
        {
            // update text  
            // Document.Text = SpellChecker.Text;
            System.Console.WriteLine($"MisspelledWord Word {SpellChecker.Text}");
        }

        public void RunTests()
        {
            SpellChecker.Text = "somethhuh";
            SpellChecker.SpellCheck();
        }

        public TestProgramName GetName(TestProgramName name)
        {
            return TestProgramName.DictionaryWords;
        }
    }
}