export interface IService {
    Id: number;
    Name: string;
    From: string;
    To: string;
    IsWeekly: boolean;
    Weekday: number;
    ServiceTypeId: number;
    Comment: string;
    DayOfWeek?: string;
}