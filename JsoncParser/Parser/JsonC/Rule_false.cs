namespace Global.Parser.JsonC {

  using System;
  using System.Collections.Generic;

  sealed public class Rule_false:Rule
  {
    private Rule_false(String spelling, List<Rule> rules) :
    base(spelling, rules)
    {
    }

    public override Object Accept(Visitor visitor)
    {
      return visitor.Visit(this);
    }

    public static Rule_false Parse(ParserContext context)
    {
      context.Push("false");

      Rule rule;
      bool parsed = true;
      ParserAlternative b;
      int s0 = context.index;
      ParserAlternative a0 = new ParserAlternative(s0);

      List<ParserAlternative> as1 = new List<ParserAlternative>();
      parsed = false;
      {
        int s1 = context.index;
        ParserAlternative a1 = new ParserAlternative(s1);
        parsed = true;
        if (parsed)
        {
          bool f1 = true;
          int c1 = 0;
          for (int i1 = 0; i1 < 1 && f1; i1++)
          {
            rule = Terminal_NumericValue.Parse(context, "%x66.61.6c.73.65", "(\\x66\\x61\\x6c\\x73\\x65)", 5);
            if ((f1 = rule != null))
            {
              a1.Add(rule, context.index);
              c1++;
            }
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }

      b = ParserAlternative.GetBest(as1);

      parsed = b != null;

      if (parsed)
      {
        a0.Add(b.rules, b.end);
        context.index = b.end;
      }

      rule = null;
      if (parsed)
      {
          rule = new Rule_false(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
      }
      else
      {
          context.index = s0;
      }

      context.Pop("false", parsed);

      return (Rule_false)rule;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
