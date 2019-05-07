using System;
using System.Collections.Generic;

using Monkey.Shared;
using static Monkey.Evaluator.Utilities;
using Object = Monkey.Shared.Object;

namespace Monkey
{
    public partial class Compiler
    {
        private CompilerState CompileExpression(CompilerState previousState)
        {
            var expression = ((Statement)previousState.Node).Expression;
            var expressionState = CompileExpressionInner(expression, previousState);

            // Add Pop instruction after every expression to clean up the stack
            return Factory.CompilerState()
                .Assign(expressionState)
                .Instructions(Bytecode.Create(3, new List<int>()))
                .Create();
        }

        private CompilerState CompileExpressionInner(Expression expression, CompilerState previousState)
        {
            switch (expression.Kind)
            {
                case ExpressionKind.Integer:
                    return CompileIntegerExpression(expression, previousState);
                case ExpressionKind.Infix:
                    return CompileInfixExpression(expression, previousState);
            }

            return previousState;
        }

        private CompilerState CompileInfixExpression(Expression expression, CompilerState previousState)
        {
            var infixExpression = (InfixExpression)expression;
            var leftExpressionState = CompileExpressionInner(infixExpression.Left, previousState);
            var rightExpressionState = CompileExpressionInner(infixExpression.Right, leftExpressionState);
            
            List<byte> op;

            switch (infixExpression.Operator.Kind)
            {
                case SyntaxKind.Plus:
                    op = Bytecode.Create(2, new List<int>());
                    break;
                case SyntaxKind.Minus:
                    op = Bytecode.Create(4, new List<int>());
                    break;
                case SyntaxKind.Asterisk:
                    op = Bytecode.Create(5, new List<int>());
                    break;
                case SyntaxKind.Slash:
                    op = Bytecode.Create(6, new List<int>());
                    break;
                default:
                    op = new List<byte>();
                    break;
            }

            return Factory.CompilerState()
                .Assign(rightExpressionState)
                .Instructions(op)
                .Create();
        }

        private CompilerState CompileIntegerExpression(Expression expression, CompilerState previousState)
        {
            var integerExpression = (IntegerExpression)expression;
            var instruction = Bytecode.Create(1, new List<int> { integerExpression.Value });

            return Factory.CompilerState()
                .Assign(previousState)
                .Constant(integerExpression.Value.ToString(), CreateObject(ObjectKind.Integer, integerExpression.Value))
                .Instructions(instruction)
                .Create();
        }
    }
}