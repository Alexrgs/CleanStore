import authService from '../components/api-authorization/AuthorizeService';

export class ApiClientBase {

    protected getBaseUrl(url, baseUrl) {
        return baseUrl;
    }

    protected async transformOptions(options: RequestInit): Promise<RequestInit> {

        const token = await authService.getAccessToken();
        
        if (token) {
            options.headers = { 'Authorization': `Bearer ${token}` };
        }
       
        return Promise.resolve(options);
    }

    protected transformResult(url: string, response: Response, processor: (response: Response) => any) {
        return processor(response);
    }
}