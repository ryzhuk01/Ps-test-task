export interface FormSubmission {
    id: string;
    formName: string;
    formData: Record<string, any>;
    submittedAt: string;
}

export interface CreateSubmissionRequest {
    formName: string;
    formData: Record<string, any>;
}
