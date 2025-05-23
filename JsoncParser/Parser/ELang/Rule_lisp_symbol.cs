namespace Global.Parser.ELang {

  using System;
  using System.Collections.Generic;

  sealed public class Rule_lisp_symbol:Rule
  {
    private Rule_lisp_symbol(String spelling, List<Rule> rules) :
    base(spelling, rules)
    {
    }

    public override Object Accept(Visitor visitor)
    {
      return visitor.Visit(this);
    }

    public static Rule_lisp_symbol Parse(ParserContext context)
    {
      context.Push("lisp-symbol");

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
            int g1 = context.index;
            List<ParserAlternative> as2 = new List<ParserAlternative>();
            parsed = false;
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Rule_lisp_char.Parse(context);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                while (f2)
                {
                  rule = Rule_lisp_char.Parse(context);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = true;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }

            b = ParserAlternative.GetBest(as2);

            parsed = b != null;

            if (parsed)
            {
              a1.Add(b.rules, b.end);
              context.index = b.end;
            }
            f1 = context.index > g1;
            if (parsed) c1++;
          }
          parsed = c1 == 1;
        }
        if (parsed)
        {
          as1.Add(a1);
        }
        context.index = s1;
      }
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
            int g1 = context.index;
            List<ParserAlternative> as2 = new List<ParserAlternative>();
            parsed = false;
            {
              int s2 = context.index;
              ParserAlternative a2 = new ParserAlternative(s2);
              parsed = true;
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  int g2 = context.index;
                  List<ParserAlternative> as3 = new List<ParserAlternative>();
                  parsed = false;
                  {
                    int s3 = context.index;
                    ParserAlternative a3 = new ParserAlternative(s3);
                    parsed = true;
                    if (parsed)
                    {
                      bool f3 = true;
                      int c3 = 0;
                      for (int i3 = 0; i3 < 1 && f3; i3++)
                      {
                        rule = Terminal_StringValue.Parse(context, ":");
                        if ((f3 = rule != null))
                        {
                          a3.Add(rule, context.index);
                          c3++;
                        }
                      }
                      parsed = c3 == 1;
                    }
                    if (parsed)
                    {
                      as3.Add(a3);
                    }
                    context.index = s3;
                  }
                  {
                    int s3 = context.index;
                    ParserAlternative a3 = new ParserAlternative(s3);
                    parsed = true;
                    if (parsed)
                    {
                      bool f3 = true;
                      int c3 = 0;
                      for (int i3 = 0; i3 < 1 && f3; i3++)
                      {
                        rule = Terminal_StringValue.Parse(context, "\\");
                        if ((f3 = rule != null))
                        {
                          a3.Add(rule, context.index);
                          c3++;
                        }
                      }
                      parsed = c3 == 1;
                    }
                    if (parsed)
                    {
                      as3.Add(a3);
                    }
                    context.index = s3;
                  }

                  b = ParserAlternative.GetBest(as3);

                  parsed = b != null;

                  if (parsed)
                  {
                    a2.Add(b.rules, b.end);
                    context.index = b.end;
                  }
                  f2 = context.index > g2;
                  if (parsed) c2++;
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                for (int i2 = 0; i2 < 1 && f2; i2++)
                {
                  rule = Rule_lisp_char.Parse(context);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = c2 == 1;
              }
              if (parsed)
              {
                bool f2 = true;
                int c2 = 0;
                while (f2)
                {
                  rule = Rule_lisp_char.Parse(context);
                  if ((f2 = rule != null))
                  {
                    a2.Add(rule, context.index);
                    c2++;
                  }
                }
                parsed = true;
              }
              if (parsed)
              {
                as2.Add(a2);
              }
              context.index = s2;
            }

            b = ParserAlternative.GetBest(as2);

            parsed = b != null;

            if (parsed)
            {
              a1.Add(b.rules, b.end);
              context.index = b.end;
            }
            f1 = context.index > g1;
            if (parsed) c1++;
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
          rule = new Rule_lisp_symbol(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
      }
      else
      {
          context.index = s0;
      }

      context.Pop("lisp-symbol", parsed);

      return (Rule_lisp_symbol)rule;
    }
  }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
