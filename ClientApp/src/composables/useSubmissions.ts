import { ref } from 'vue';
import api from '../services/api';
import type { FormSubmission, CreateSubmissionRequest } from '../types/submission';

export function useSubmissions() {
    const isLoading = ref(false);
    const error = ref<string | null>(null);

    const fetchSubmissions = async (search?: string): Promise<FormSubmission[]> => {
        isLoading.value = true;
        error.value = null;
        try {
            const params = search ? { search } : {};
            const response = await api.get<FormSubmission[]>('', { params });
            return response.data;
        } catch (err: any) {
            error.value = err.message || 'Failed to fetch submissions';
            throw err;
        } finally {
            isLoading.value = false;
        }
    };

    const createSubmission = async (data: CreateSubmissionRequest): Promise<string> => {
        isLoading.value = true;
        error.value = null;
        try {
            const response = await api.post<{ id: string }>('', data);
            return response.data.id;
        } catch (err: any) {
            error.value = err.message || 'Failed to create submission';
            throw err;
        } finally {
            isLoading.value = false;
        }
    };

    return {
        isLoading,
        error,
        fetchSubmissions,
        createSubmission,
    };
}
