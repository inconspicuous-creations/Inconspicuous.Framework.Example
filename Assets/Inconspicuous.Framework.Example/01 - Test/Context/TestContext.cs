using System.Collections.Generic;
using UniRx;

namespace Inconspicuous.Framework.Example.Test {
	[Scene("Test")]
	public class TestContext : Context {
		public TestContext(IContextView contextView, params Context[] subContexts)
			: base(contextView, subContexts) {
			ContextConfiguration.Default.Configure(container);
			container.RegisterDecorator<ICommandHandler<StartCommand, Unit>, DebugCommandHandlerDecorator<StartCommand, Unit>>(Reuse.Singleton);
			container.RegisterDecorator<ICommandHandler<TestCommand, Unit>, DebugCommandHandlerDecorator<TestCommand, Unit>>(Reuse.Singleton);
			container.RegisterDecorator<ICommandHandler<MacroCommand, ICollection<object>>, DebugCommandHandlerDecorator<MacroCommand, ICollection<object>>>(Reuse.Singleton);
		}

		public override void Start() {
			container.Resolve<IViewMediationBinder>().Mediate(container.Resolve<IContextView>());
			container.Resolve<ICommandDispatcher>().Dispatch(new StartCommand()).Subscribe().AddTo(this);
		}
	}
}
