namespace GameOfChores.Application.UseCases.GetChoreTypes
{
    public class GetChoreTypesResult
    {
        public string Label { get; set; }

        public GetChoreTypesResult(string label)
        {
            Label = label;
        }
    }
}
