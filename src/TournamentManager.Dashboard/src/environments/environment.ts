export interface IEnvironment {
  production:boolean;
  apiUrl:string;
}

export const environment: IEnvironment = {
  production: false,
  apiUrl: 'https://localhost:7290',
};


