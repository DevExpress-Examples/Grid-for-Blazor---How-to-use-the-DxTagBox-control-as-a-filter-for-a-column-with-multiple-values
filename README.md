<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1104359)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Grid for Blazor - How to use the DxTagBox control as a filter for a column with multiple values

In this example, we use our [DxTagBox](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxTagBox-2) control alongside the DevExpress Blazor Control to filter column data against multiple filter values (DXTagBox is used within the [DxGridDataColumn.FilterRowCellTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridDataColumn.FilterRowCellTemplate)).

![image](https://user-images.githubusercontent.com/69251191/180018055-298229e1-745b-46b7-984f-592c7d486e1e.png)

To incorporate this capability in your next Blazor-powered project, you’ll need to handle the [DxTagBox](http://docs.devexpress.devx/Blazor/DevExpress.Blazor.DxTagBox-2) [ValuesChanged](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxTagBox-2.ValuesChanged) event (set `context.FilterCriteria` to custom filter criteria). Custom filter criteria are created based on values selected within the TagBox control.

```razor
<DxGridDataColumn FieldName="SummaryString" >
    <FilterRowCellTemplate>
        @{
            var items = TagBoxFilterRowUtils.GetValueByFunctionOperator(context.FilterCriteria, nameof(WeatherForecast.Summary));
        }   
        <DxTagBox TData="string"
                  TValue="string"
                  Data="Summaries"
                  Values="items"
                  ValuesChanged="(newValues) => { context.FilterCriteria = TagBoxFilterRowUtils.CreateFilterCriteriaByValues(newValues, nameof(WeatherForecast.Summary)); }" />
    </FilterRowCellTemplate>
</DxGridDataColumn>
```

```cs
    public class TagBoxFilterRowUtils
    {
        public static IEnumerable<string> GetValueByFunctionOperator(CriteriaOperator criteria, string fieldName)
        {
            var aggregateOperand = criteria as AggregateOperand;
            if (aggregateOperand.ReferenceEqualsNull() || aggregateOperand.AggregateType != Aggregate.Exists)
                return null;
            if (aggregateOperand.CollectionProperty is not OperandProperty operandProperty || operandProperty.PropertyName != fieldName)
                return null;
            if (aggregateOperand.Condition is not InOperator inOperator)
                return null;
            return inOperator.Operands.OfType<OperandValue>().Select(r => r.Value?.ToString());
        }

        public static CriteriaOperator CreateFilterCriteriaByValues(IEnumerable<string> values, string fieldName)
        {
            if (values.Count() == 0)
                return null;
            return new AggregateOperand(fieldName, Aggregate.Exists, new InOperator("", values));
        }
    }
```


## Files to Review

* [Index.razor](./CS/DxBlazorApplication1/Pages/Index.razor)
* [TagBoxFilterRowUtils.cs](./CS/DxBlazorApplication1/TagBoxFilterRowUtils.cs)

