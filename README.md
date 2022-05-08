## Sample testing framework using Selenium-CSharp
The aim of this project is to serve as a start point for testers who may want to build a Selenium-C# framework from scratch for a test automation project.

---

### Notes
- Why xUnit?
  1. Test run in parallel with no further configuration.
  2. Less annotations, which makes your life easier. Check [here](https://xunit.net/docs/comparisons) to know what I mean.

- Main takeaways:
  1. **Always** use a design pattern to keep separated your framework, the interactions with the [SUT](#sut) and your tests. This way your tests will be much more resilient. In this project the Page Object pattern was implemented.
  2. Insert logs for the main interactions with the [SUT](#sut). This way, if a test fails, it is easier to know at what point it failed and why.
  3. Configure your framework to take a screenshot every time a test fail. It will be easier to investigate the failure.

---

*SUT: Software under test [#sut]
