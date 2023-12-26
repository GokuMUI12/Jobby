export interface Job{
    id: number;
    budget: number;
    expectedDays: number;
    description: string
    title: string;    
    skills: string[];
    categoryId : number
    created: Date
}

export interface JobCategory{
    id : number;
    categoryName: string
}