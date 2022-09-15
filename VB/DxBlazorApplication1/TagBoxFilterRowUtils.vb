Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Filtering.Helpers

Namespace DxBlazorApplication1

    Public Class TagBoxFilterRowUtils

        Public Shared Function GetValueByFunctionOperator(ByVal criteria As CriteriaOperator, ByVal fieldName As String) As IEnumerable(Of String)
            Dim aggregateOperand = TryCast(criteria, AggregateOperand)
            If aggregateOperand.ReferenceEqualsNull() OrElse aggregateOperand.AggregateType IsNot Aggregate.Exists Then Return Nothing
            Dim OperandProperty As [not] = Nothing
            If CSharpImpl.__Assign(OperandProperty, TryCast(aggregateOperand.CollectionProperty, [not])) IsNot Nothing Then operandProperty OrElse operandProperty.PropertyName IsNot fieldName
            Return Nothing
            Dim InOperator As [not] = Nothing
            If CSharpImpl.__Assign(InOperator, TryCast(aggregateOperand.Condition, [not])) IsNot Nothing Then inOperator
            Return Nothing
            Return inOperator.Operands.OfType(Of OperandValue)().[Select](Function(r) r.Value?.ToString())
        End Function

        Public Shared Function CreateFilterCriteriaByValues(ByVal values As IEnumerable(Of String), ByVal fieldName As String) As CriteriaOperator
            If values.Count() Is 0 Then Return Nothing
            Return New AggregateOperand(fieldName, Aggregate.Exists, New InOperator("", values))
        End Function

        Private Class CSharpImpl

            <System.Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
