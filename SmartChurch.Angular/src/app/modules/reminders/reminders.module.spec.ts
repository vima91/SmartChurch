import { RemindersModule } from './reminders.module';

describe('RemindersModule', () => {
  let remindersModule: RemindersModule;

  beforeEach(() => {
    remindersModule = new RemindersModule();
  });

  it('should create an instance', () => {
    expect(remindersModule).toBeTruthy();
  });
});
